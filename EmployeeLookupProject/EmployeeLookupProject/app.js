var module = angular.module("myApp", ['ngResource', 'ngFileUpload']);


module.controller('myCtrl', function ($scope, baseURL, $resource, Upload, $timeout) {

    $scope.displayMode = "list";

    $scope.currentEmployee = null;

    $scope.employeesResource = $resource(baseURL + ":id", { id: '@EmployeeId' },
    {
        update: {
            method: 'PUT' // this method issues a PUT request
        }
    });

    $scope.listEmployees = function () {

        $scope.employees = $scope.employeesResource.query();
        console.log($scope.employees);
    }

    $scope.deleteEmployee = function (employee) {
        employee.$delete().then(function () {
            $scope.employees.splice($scope.employees.indexOf(employee), 1);
        });
    }

    $scope.createemployee = function (employee) {
        new $scope.employeesResource(employee).$save().then(function (newemployee) {
            $scope.employees.push(newemployee);
            $scope.displayMode = "list";
        });
    }

    $scope.updateemployee = function (employee) {
        console.log($scope.currentEmployee.Picture);
        employee.$update(function () {
            $scope.listEmployees();
        });
        $scope.displayMode = "list";
    }

    $scope.editOrCreateEmployee = function (employee) {
        $scope.currentEmployee = employee ? angular.copy(employee) : {};
        $scope.displayMode = "edit";
    }

    $scope.saveEdit = function (employee) {
        if (angular.isDefined(employee.EmployeeId)) {
            $scope.updateemployee(employee);
        } else {
            $scope.createemployee(employee);
        }
    }

    $scope.cancelEdit = function () {
        if ($scope.currentEmployee && $scope.currentEmployee.$get) {
            $scope.currentEmployee.$get();
        }
        $scope.currentEmployee = {};
        $scope.displayMode = "list";
    }


    $scope.uploadFiles = function (file, errFiles) {
        $scope.f = file;
        $scope.errFile = errFiles && errFiles[0];
        if (file) {
            file.upload = Upload.upload({
                url: baseURL + '/images',
                data: { file: file }
            });

            file.upload.then(function (response) {
                $timeout(function () {
                    $scope.currentEmployee.Picture = response.data;
                });
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            });
        }
    }

    $scope.listEmployees();
});

module.value('baseURL', window.location + '/api/Employees/');

