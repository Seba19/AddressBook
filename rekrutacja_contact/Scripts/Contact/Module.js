var app = angular.module("ContactBook", []);
var baseAddress = '/api/Contacts/';
var url = "";

app.factory('contactFactory', function ($http) {
    return {
        getContactsList: function () {
            url = baseAddress ;
            return $http.get(url);
        },
       
        addContact: function (contact) {
            url = baseAddress ;
            return $http.post(url, contact);
        },
        deleteContact: function (contact) {
            url = baseAddress +"/" +contact.Id;
            return $http.delete(url);
        },
        updateContact: function (contact) {
            url = baseAddress +"/"+ contact.Id;
            return $http.put(url, contact);
        }
    };
});