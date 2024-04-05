function validateForm() {
    let uname = document.forms["myForm"]["username"].value;
    if(uname == "")
    {
        alert("please enter username");
        return false;
    }

    let pass = document.forms["myForm"]["password"].value;
    if(pass == "")
    {
        alert("please enter password");
        return false;
    }

    var dd = document.getElementById("location");
    var dd_val = dd.options[dd.selectedIndex].value;
    if (dd_val == 0)
    {
        alert('please select city');
        return false;
    }

    var option = document.getElementsByName('gender');

    if (!(option[0].checked || option[1].checked)) {
        alert("please select gender");
        return false;
    }


    var i,
    chks = document.getElementsByName('tech');

    for (i = 0; i < chks.length; i++)
    {
        if (chks[i].checked)
        {
            return true;
        }
        else
        {
            alert('please select at least 1 technology');
            return false; 
        }
    }
}
