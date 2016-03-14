app.controller('ContactController', function PostController($scope, contactFactory) {
        $scope.message = ' Hello';
        $scope.contacts = [];
        $scope.contact = null;
        $scope.editMode = false;
 
        //Other code has been removed for clarity
 
  
        $scope.get = function () {
            $scope.contact = this.contact;
            $('#viewModal').modal('show');
        };
 
    
        $scope.getAll = function () {
            contactFactory.getContactsList().success(function (data) {
                $scope.contacts = data;
            }).error(function (data) {
                $scope.error = "Problem przy pobieraniu kontaktów! " + data.ExceptionMessage;
            });
        };
 
     // add 
        $scope.add = function () {
            var currentContact = this.contact;
            if (currentContact != null && currentContact.Name != null && currentContact.Surname != null) {
                contactFactory.addContact(currentContact).success(function (data) {
                    $scope.addMode = false;
                    currentContact.Id = data.Id;
                    $scope.contacts.push(currentContact);
 
                    //reset form
                    $scope.contact = null;
                   
 
                    $('#contactModel').modal('hide');
                }).error(function (data) {
                    $scope.error = "Błąd podczas dodawania nowego kontaktu! " + data.ExceptionMessage;
                });
            }
        };
 
     //edit contact
        $scope.edit = function () {
            $scope.contact = this.contact; 
            $scope.editMode = true;
            $('#contactModel').modal('show');
        };
 
     //update contact
        $scope.update = function () {
            var currentContact = this.contact;
            contactFactory.updateContact(currentContact).success(function (data) {
                currentContact.editMode = false;
 
                $('#contactModel').modal('hide');
            }).error(function (data) {
                $scope.error = "|Błąd podczas edycji kontaktu! " + data.ExceptionMessage;
            });
        };
 
     // delete 
        $scope.delete = function () {
            currentContact = $scope.contact;
            contactFactory.deleteContact(currentContact).success(function (data) {
                $('#confirmModal').modal('hide');
                $scope.contacts.pop(currentContact);
 
            }).error(function (data) {
                $scope.error = "Błąd podczas usuwania kontaktu! " + data.ExceptionMessage;
 
                $('#confirmModal').modal('hide');
            });
        };
 
     //Model popup events
        $scope.showadd = function () {
            $scope.contact = null;
            $scope.editMode = false;
            $('#contactModel').modal('show');
        };
 
        $scope.showedit = function () {
            $('#contactModel').modal('show');
        };
 
        $scope.showconfirm = function (data) {
            $scope.contact = data;
            $('#confirmModal').modal('show');
        };
 
        $scope.cancel = function () {
            $scope.contact = null;
            $('#contactModel').modal('hide');
        }
 
        $scope.getAll();
 });
 
    