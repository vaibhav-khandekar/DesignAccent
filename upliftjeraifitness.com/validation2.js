var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope, $http) {

    $scope.validate2 = function () {
        // full name
        let fname = document.forms["Jerai_form"]["txtFullName"].value;
        if (fname == "") {
            alert("please enter full name");
            return false;
        }

        /* email address validation
        let email = document.forms["Jerai_form"]["txtEmail"].value;
        if (email == "") {
            alert("please enter email address");
            return false;
        }*/

        // email address validation using regex
        let email = document.forms["Jerai_form"]["txtEmail"].value;
        var regexEmail = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
        if (!regexEmail.test(email)) {
            alert('please enter a valid email address');
            email.focus;
            return false;
        }

        /* phone number validation
        let phone = document.forms["Jerai_form"]["txtMobile"].value;
        if(phone == "")
        {
            alert("please enter phone number");
            return false;
        }
        */

        // phone number validation using regex
        let phone = document.forms["Jerai_form"]["txtMobile"].value;
        var regexPhone = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
        if (!regexPhone.test(phone)) {
            alert('please enter valid phone number');
            return false;
        }

        // state
        var state = document.getElementById("selectState");
        var state_val = state.options[state.selectedIndex].value;
        if (state_val == 0) {
            alert('please select state');
            return false;
        }

        // city
        var city = document.getElementById("selectCity");
        var city_val = city.options[city.selectedIndex].value;
        if (city_val == 0) {
            alert('please select city');
            return false;
        }

        // gender
        var gender = document.getElementById("ddlgender");
        var gender_val = gender.options[gender.selectedIndex].value;
        if (gender_val == 0) {
            alert('please select gender');
            return false;
        }

        // bodybuilding / powerlifting
        /*
        var tab1 = document.getElementById("TabBodybuilding").classList.contains("active");
        var tab2 = document.getElementById("TabPowerlifting").classList.contains("active");

        // bodybuilding tab
        if (tab1) {
            // past achievements and competitions won
            var build_won = document.getElementsByName('rdoAchievementsBodyBuilding');

            if (!(build_won[0].checked || build_won[1].checked || build_won[2].checked || build_won[3].checked)) {
                alert("please select past achievements and competitions won");
                return false;
            }

            // pro championship
            var pro = document.getElementsByName('rdoRunnerUpBodyBuilding');

            if (!(pro[0].checked || pro[1].checked || pro[2].checked || pro[3].checked || pro[4].checked)) {
                alert("please select pro championship");
                return false;
            }

            // points calculation
            var level = parseInt(document.querySelector('input[name="rdoRunnerUpBodyBuilding"]:checked').value);
            var champ = parseInt(document.querySelector('input[name="rdoAchievementsBodyBuilding"]:checked').value);
            var totalPoints = level + champ;
            document.getElementById("lblpoints").textContent = +totalPoints;

            // date of completion
            var dateInput = document.getElementById("txtdateOfBodyBuilding").value;
            if (dateInput === "") {
                alert("Please select a date");
            }

            // photo link 1
            let pl_bb_1 = document.forms["Jerai_form"]["txtPhotoLink1BodyBuilding"].value;
            if (pl_bb_1 == "") {
                alert("please enter photo link 1");
                return false;
            }

            // photo link 2
            let pl_bb_2 = document.forms["Jerai_form"]["txtPhotoLink2BodyBuilding"].value;
            if (pl_bb_2 == "") {
                alert("please enter photo link 2");
                return false;
            }

            // photo link 3
            let pl_bb_3 = document.forms["Jerai_form"]["txtPhotoLink3BodyBuilding"].value;
            if (pl_bb_3 == "") {
                alert("please enter photo link 3");
                return false;
            }
        }

            // powerlifting tab
        else if (tab2) {

            if (gender == 'male') {
                // weight classes for men
                var men_weight = document.getElementById("selectMenWeight");
                var men_val = men_weight.options[men_weight.selectedIndex].value;
                if (men_val == 0) {
                    alert('please select mens\'s weight class');
                    return false;
                }
            }
            else {
                // weight classes for women
                var women_weight = document.getElementById("selectWomenWeight");
                var women_val = women_weight.options[women_weight.selectedIndex].value;
                if (women_val == 0) {
                    alert('please select womens\'s weight class');
                    return false;
                }
            }
            

            // past achievements and competitions won
            var lift_won = document.getElementsByName('rdoAchievementsPowerlifting');

            if (!(lift_won[0].checked || lift_won[1].checked || lift_won[2].checked)) {
                alert("please select past achievements and competitions won");
                return false;
            }

            // date of completion
            var dateInput = document.getElementById("txtDatePowerlifting").value;
            if (dateInput === "") {
                alert("Please select a date");
            }

            // photo link 1
            let pl_pl_1 = document.forms["Jerai_form"]["txtPhotoLink1Powerlifting"].value;
            if (pl_pl_1 == "") {
                alert("please enter photo link 1");
                return false;
            }

            // photo link 2
            let pl_pl_2 = document.forms["Jerai_form"]["txtPhotoLink2Powerlifting"].value;
            if (pl_pl_2 == "") {
                alert("please enter photo link 2");
                return false;
            }

            // photo link 3
            let pl_pl_3 = document.forms["Jerai_form"]["txtPhotoLink3Powerlifting"].value;
            if (pl_pl_3 == "") {
                alert("please enter photo link 3");
                return false;
            }
        }

            // if bodybuilding or weightlifting tab is unfilled
        else {
            // if not selected either body building or power lifting
            alert("please fill information from bodybuilding tab or power lifting tab");
        }*/

        // terms and conditions checkbox
        var checkBox = document.getElementById("cboxAgree");
        if (!checkBox.checked) {
            alert("please agree to the terms and conditions.");
            return false;
        }

        // submit button
        var submit = document.getElementById("submitBtn");
        /*if (submit) {
            swal({
                title: "Good job!",
                text: "You clicked the button!",
                icon: "success",
                button: "Aww yiss!",
            });
        }*/

        if (submit) {
            swal({
                title: "Are you sure?",
                text: "Once submitted, your details will be submitted to VK CLASHER!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
            .then((willSubmit) => {
                if (willSubmit) {
                    swal("Done! your details submitted to VK CLASHER!", {
                        icon: "success",
                    });
                } else {
                    swal("Your details is not shared yet!");
                }
            });
        }

        var objData = {
            //API:data
            "FullName": fname,
            "EmailAddress": email,
            "MobileNumber": phone,
            "Statee": state_val,
            "City": city_val,
            "Gender": gender_val
        }
        $http.post('http://localhost:53030/Validation/AddDetails', JSON.stringify(objData), { header: { 'Content-Type': "application/json" } }).
             then(function (response) {
                 //response.data.Message
                 //response.data.Code
                 //response.data.ListName
                 if (response.data.Code == 201) {
                     alert("Insert successfull");
                 }
                 // this callback will be called asynchronously
                 // when the response is available
             }, function (error) {
                 alert("someting went wrong");
             });
        console.log(fname, email, phone, state, city, gender);
        //$http({ method: 'POST', url: "http://localhost:53030/Validation/AddDetails" })
    }
});
