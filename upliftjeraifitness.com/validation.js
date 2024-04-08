function validate()
{
    // full name
    let fname = document.forms["Jerai_form"]["txtFullName"].value;
    if (fname == "") {
        alert("please enter full name");
        return false;
    }

    // email address
    let email = document.forms["Jerai_form"]["txtEmail"].value;
    if (email == "") {
        alert("please enter email address");
        return false;
    }

    // phone number
    let phone = document.forms["Jerai_form"]["txtMobile"].value;
    if(phone == "")
    {
        alert("please enter phone number");
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

    var tabName = document.getElementById("TabBodybuilding").getAttribute("rel");
    if (tabName === 'TabBodybuilding') {
        // bodybuilding tab
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

    }
    else if (tabName === 'TabPowerlifting') {

        // powerlifting tab

        // weight classes for men
        var men_weight = document.getElementById("selectMenWeight");
        var men_val = men_weight.options[men_weight.selectedIndex].value;
        if (men_val == 0) {
            alert('please select weight class');
            return false;
        }

        // weight classes for women
        var women_weight = document.getElementById("selectWomenWeight");
        var women_val = women_weight.options[women_weight.selectedIndex].value;
        if (women_val == 0) {
            alert('please select weight class');
            return false;
        }

        // past achievements and competitions won
        var lift_won = document.getElementsByName('rdoAchievementsPowerlifting');

        if (!(lift_won[0].checked || lift_won[1].checked || lift_won[2].checked)) {
            alert("please select past achievements and competitions won");
            return false;
        }

    } else {
        // if not selected either body building or power lifting
        console.log("please fill information from bodybuilding tab or power lifting tab");
    }
  
    // date of completion
    let date = document.getElementById("txtdateOfBodyBuilding").value;
    let dateObj = new Date(date);
    console.log(date);

    // photo link 1
    let ph1 = document.forms["Jerai_form"]["txtPhotoLink1BodyBuilding"].value;
    if (ph1 == "") {
        alert("please enter photo link 1");
        return false;
    }

    // photo link 2
    let ph2 = document.forms["Jerai_form"]["txtPhotoLink2BodyBuilding"].value;
    if (ph2 == "") {
        alert("please enter photo link 2");
        return false;
    }

    // photo link 3
    let ph3 = document.forms["Jerai_form"]["txtPhotoLink3BodyBuilding"].value;
    if (ph3 == "") {
        alert("please enter photo link 3");
        return false;
    }

    // terms and conditions checkbox
    var checkBox = document.getElementById("cboxAgree");
    if (!checkBox.checked) {
        alert("please agree to the terms and conditions.");
        return false;
    }
    return true;
}
