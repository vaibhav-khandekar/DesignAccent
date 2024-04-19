var app = angular.module('addNewLeadApp', []);

app.controller('addNewLeadCtrl', function ($scope) {
    $scope.validate = function () {
        // contact person name
        let name = document.forms["add-new-lead-form"]["txtName"].value;
        if (name == "") {
            alert("please enter name");
            return false;
        }

        // city
        let city = document.forms["add-new-lead-form"]["txtCity"].value;
        if (city == "") {
            alert("please enter city");
            return false;
        }

        // age
        let age = document.forms["add-new-lead-form"]["txtAge"].value;
        if (age == "") {
            alert("please enter age");
            return false;
        }

        // gender
        var maleRadio = document.getElementById("male");
        var femaleRadio = document.getElementById("female");
        if (maleRadio.checked == false && femaleRadio.checked == false) {
            alert("Please select your gender.");
            return false;
        }

        // source
        let source = document.forms["add-new-lead-form"]["txtSource"].value;
        if (source == "") {
            alert("please enter source");
            return false;
        }

        // mobile number
        let phone = document.forms["add-new-lead-form"]["txtMobile"].value;
        var regexPhone = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
        if (!regexPhone.test(phone)) {
            alert('please enter valid phone number');
            return false;
        }

        // email id validation using regex
        let email = document.forms["add-new-lead-form"]["txtEmail"].value;
        var regexEmail = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
        if (!regexEmail.test(email)) {
            alert('please enter a valid email id');
            email.focus;
            return false;
        }

        // date
        var dateInbuilt = document.getElementById('txtDate');
        var currentDate = new Date().toISOString().split('T')[0]; // Get current date in YYYY-MM-DD format
        console.log(currentDate);
        dateInbuilt.value = currentDate;

        // address
        let address = document.forms["add-new-lead-form"]["textareaAddress"].value;
        if (address == "") {
            alert("please enter address");
            return false;
        }

        // query
        let query = document.forms["add-new-lead-form"]["textareaQuery"].value;
        if (query == "") {
            alert("please enter query");
            return false;
        }

        // lead status
        var lead_status = document.getElementById("selectLeadStatus");
        var lead_status_val = lead_status.options[lead_status.selectedIndex].value;
        if (lead_status_val == 0) {
            alert('please select lead status');
            return false;
        }

        // lead type
        var lead_type = document.getElementById("selectLeadType");
        var lead_type_val = lead_type.options[lead_type.selectedIndex].value;
        if (lead_type_val == 0) {
            alert('please select lead type');
            return false;
        }

        // next follow up date
        var dateInput = document.getElementById("txtFollowUpDate").value;
        if (dateInput === "") {
            alert("Please select a date");
        }

        // next follow up time
        var timeInput = document.getElementById("txtFollowUpTime").value;
        let regexTime = new RegExp(/((1[0-2]|0?[1-9]):([0-5][0-9]) ?([AaPp][Mm]))/);
        if (timeInput == "") {
            alert("please enter time");
        }
        else {
            if (regexTime.test(timeInput) != true) {
                alert('please enter valid time')
            }
        }

        // feedback
        let feedback = document.forms["add-new-lead-form"]["txtFeedback"].value;
        if (feedback == "") {
            alert("please give some feedback");
            return false;
        }

        // assign to doctor
        var doctor_type = document.getElementById("selectDoctor");
        var doctor_type_val = doctor_type.options[doctor_type.selectedIndex].value;
        if (doctor_type_val == 0) {
            alert('please select lead type');
            return false;
        }

        // delivery
        var selfPickUpRadio = document.getElementById("self-pickup");
        var courierRadio = document.getElementById("courier");
        if (selfPickUpRadio.checked == false && courierRadio.checked == false) {
            alert("please select form of delivery");
            return false;
        }

        // payment
        var codRadio = document.getElementById("cod");
        var onlinePaymentRadio = document.getElementById("online-payment");
        if (codRadio.checked == false && onlinePaymentRadio.checked == false) {
            alert("please select payment mode");
            return false;
        }

        // offer
        var discountedRadio = document.getElementById("discounted");
        var mrpRadio = document.getElementById("mrp");
        if (discountedRadio.checked == false && mrpRadio.checked == false) {
            alert("please select offer");
            return false;
        }

        // discounted
        if (discountedRadio.checked == true) {
            var discounted = document.getElementById("selectDiscount");
            var discounted_val = discounted.options[discounted.selectedIndex].value;
            if (discounted_val == 0) {
                alert('please select discounted value');
                return false;
            }
        }
        else {
            document.getElementById("selectDiscount").disabled = true;
        }

        // reason
        let reason = document.forms["add-new-lead-form"]["txtReason"].value;
        if (reason == "") {
            alert("please enter reason");
            return false;
        }
    }
});
