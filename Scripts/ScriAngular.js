var app = angular.module("AngularApp", []);
app.controller("AdminViewModel", function ($scope, $http) {

    $scope.Admin = {
        "Id": "",
        "FirstName": "",
        "LastName": "",
        "UserName": "",
        "Password": ""
    };

    $scope.Disable = true;

    $scope.loginWatcher = function (username,password) {
        if (username.length == 0 || password.length == 0) {
            $scope.Disable = true;
        }
        else {
            $scope.Disable = false;
        }
    };

    $scope.ErrorMessage = "";

    $scope.Admins = {};

    $scope.LoadAdmins = function () {
        $http({ method: "GET", url: "/API/Values/GetAdmins" }).
        success(function (data, status, headers, config) {
            $scope.Admins = data;
        });
    };

    $scope.AddAdmin = function () { // Make a call to the server and send customer data (By Json)
        $http({ method: "POST", data: $scope.Admin, url: "/API/Values/PostAdmin" }).
        success(function (data, status, headers, config) {
            // Load customer tables again and reset the form
            $scope.Admins = data;
        });
    };

    $scope.Clear = function () {
        $scope.Admin = {
            "Id": "",
            "FirstName": "",
            "LastName": "",
            "UserName": "",
            "Password": ""
        };
    };

    $scope.GetAdminData = function () {
        $scope.Admin = {
            "Id": "",
            "FirstName": "",
            "LastName": "",
            "UserName": "",
            "Password": ""
        };
    };

    $scope.EditAdmin = function (id, firstName, lastName, userName, password) {
        $scope.Admin.Id = id;
        $scope.Admin.FirstName = firstName;
        $scope.Admin.LastName = lastName;
        $scope.Admin.UserName = userName
        $scope.Admin.Password = password;
    };

    $scope.SaveAdmin = function () { // Make a call to the server and send customer data (By Json)
        $http({ method: "PUT", data: $scope.Admin, url: "/API/Values/PutAdmin" }).
        success(function (data, status, headers, config) {
            // Load customer tables again and reset the form
            $scope.Admins = data;
        });
    };

    $scope.DeleteAdmin = function () { // Make a call to the server and send customer data (By Json)
        $http.defaults.headers["delete"] = {
            'Content-Type': 'application/json;charset=utf-8'
        };

        $http({ method: "DELETE", data: $scope.Admin, url: "/API/Values/DeleteAdmin" }).
        success(function (data, status, headers, config) {
            // Load customer tables again 
            $scope.Admins = data;
        });
    };

    $scope.CurrentCategory = "New Product";

    $scope.ChangeCategory = function (category) {
        $scope.CurrentCategory = category;
    }

    $scope.LoadAdmins();
});

app.controller("ShopViewModel", function ($scope, $http) {

    $scope.Shop = {
        "CatalogNumber": "",
        "Name": "",
        "Price": "",
        "Quantity": "",
        "Category": "",
        "Image": ""
    };

    $scope.SearchTerm = "";

    $scope.MinPrice = "";

    $scope.MaxPrice = "";

    $scope.Products = {};

    $scope.Purchases = {};

    $scope.Categories = [];

    $scope.NewCategory = false;

    $scope.EditProduct = {
        "Name": "",
        "CatalogNumber": "",
        "Quantity": ""
    };

    $scope.UpdateQuantity = function (name,catNum,quantity) {
        $scope.Shop.Name = name;
        $scope.Shop.CatalogNumber = catNum
        $scope.Shop.Quantity = quantity;
    };

    $scope.BuyItem = function (name,price, quantity, catNum) {
        $scope.Shop.Name = name;
        $scope.Shop.CatalogNumber = catNum
        $scope.Shop.Quantity = quantity;
        $scope.Shop.Price = price;
    };

    $scope.PurchaseDetails = {
        "ProductName": "",
        "Quantity": "",
        "Sum": "",
        "BuyerName": "",
        "Date": ""
    };

    $scope.Purchase = function (name, quantity) { // Make a call to the server and send customer data (By Json)
        if ($scope.Shop.Quantity - quantity >= 0) {
            $scope.Shop.Quantity -= quantity;

            $http({ method: "PUT", data: $scope.Shop, url: "/API/Values/PutProduct" }).
            success(function (data, status, headers, config) {

                $scope.UpdatePurchasesTable(name,quantity);

                // Load customer tables again and reset the form
                $scope.Products = data;

            });
        }
    };


    $scope.UpdatePurchasesTable = function (name,quantity) { // Make a call to the server and send customer data (By Json)
        $scope.PurchaseDetails.ProductName = $scope.Shop.Name;
        $scope.PurchaseDetails.Quantity = $scope.ToBuyQuantity;
        $scope.PurchaseDetails.Sum = quantity * $scope.Shop.Price;
        $scope.PurchaseDetails.Date = new Date();
        $scope.PurchaseDetails.BuyerName = name;

        $http({ method: "POST", data: $scope.PurchaseDetails, url: "/API/Values/PostPurchase" }).
        success(function (data, status, headers, config) {
            
        });
    };
    

    $scope.UpdateProductQuantity = function () { // Make a call to the server and send customer data (By Json)
        $http({ method: "PUT", data: $scope.Shop, url: "/API/Values/PutProduct" }).
        success(function (data, status, headers, config) {
            // Load customer tables again and reset the form
            $scope.Products = data;
        });
    };

    $scope.DeleteProduct = function () { // Make a call to the server and send customer data (By Json)
        $http.defaults.headers["delete"] = {
            'Content-Type': 'application/json;charset=utf-8'
        };

        $http({ method: "DELETE", data: $scope.Shop, url: "/API/Values/DeleteProduct" }).
        success(function (data, status, headers, config) {
            // Load customer tables again 
            $scope.Products = data;
        });
    };

    $scope.CategoryChangeName = function (catName) {
        $scope.Shop.Category = catName;
    };

    $scope.SearchProduct = function (Name,SearchTerm) {
        return Name.toLowerCase().indexOf(SearchTerm.toLowerCase()) != -1;
    };

    $scope.MinPriceCheck = function (Price, MinPrice) {
        return Price <= MinPrice;
    };

    $scope.MaxPriceCheck = function (Price, MaxPrice) {
        return Price >= MaxPrice;
    };

    $scope.LoadBySearch = function () {
        $http({ method: "GET", url: "/API/Values?Name=" + $scope.Product.Name }).
        success(function (data, status, headers, config) {
            $scope.Products = data;
        });
    };

    $scope.Load = function () {
        $http({ method: "GET", url: "/API/Values/Get" }).
        success(function (data, status, headers, config) {
            $scope.Products = data;
        });
    };

    $scope.LoadPurchases = function () {
        $http({ method: "GET", url: "/API/Values/GetPurchases" }).
        success(function (data, status, headers, config) {
            $scope.Purchases = data;
        });
    };

    $scope.LoadCategories = function () {
        $http({ method: "GET", url: "/API/Values/GetCategories" }).
        success(function (data, status, headers, config) {
            $scope.Categories = data;
        });

        $scope.Shop.Category = "All";
    };

    $scope.ResetCategory = function () {
        $scope.Shop.Category = "Choose Category";
    };

    $scope.ProductCategory = function (catName) {
        $scope.Shop.Category = catName;
        $scope.NewCategory = false;
    };


    $scope.ClearProductForm = function () {
        $scope.Shop = {
            "CatalogNumber": "",
            "Name": "",
            "Price": "",
            "Quantity": "",
            "Category": "Choose Category",
            "Image": ""
        };
    };

    $scope.AddProduct = function () { // Make a call to the server and send customer data (By Json)
        $http({ method: "POST", data: $scope.Shop, url: "/API/Values/PostProduct" }).
        success(function (data, status, headers, config) {
            // Load customer tables again and reset the form
            $scope.Shop = data;
        });
    };

    $scope.TotalSold = function () {
        var total = 0;
        for (var i = 0; i < $scope.Purchases.length; i++) {
            var product = $scope.Purchases[i];
            total += (product.Quantity);
        }
        return total;
    }

    $scope.TotalIncome = function () {
        var total = 0;
        for (var i = 0; i < $scope.Purchases.length; i++) {
            var product = $scope.Purchases[i];
            total += (product.Sum);
        }
        return total;
    }

    $scope.Load();
    $scope.LoadCategories();
    $scope.LoadPurchases();
});

app.directive('errSrc', function () {
    return {
        link: function (scope, element, attrs) {
            element.bind('error', function () {
                if (attrs.src != attrs.errSrc) {
                    attrs.$set('src', attrs.errSrc);
                }
            });
        }
    }
});