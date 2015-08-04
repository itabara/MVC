function postCustomer() {
    this.launchCustomer = function () {        
        // fetch values from input
        var firstName = $("#FirstName").val();        
        var lastName = $("#LastName").val();
        var age = $("#Age").val();
        var gender = $("#Gender").val();
        var hobby = $("#Hobby").val();

        // build json object
        var customer = {
            FirstName: firstName,
            LastName: lastName,
            Age: age,
            Gender: gender,
            Hobby: hobby
        };

        $.ajax({
            type: "POST",
            url: "home/postcustomer",
            traditional: true,
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(customer),
            success: function (data) { console.log(data) },
            failure: function (data) { console.log(data) }
        })
    };
}