$(document).ready(function () {

    $('#btnCreate').click(function () {
        AddCustomer();
    });

});

function AddCustomer() {

    var fname = $("#fname").val();
    var fphone = $("#fphone").val();
    var femail = $('#femail').val();
    var faddress = $('#faddress').val();

    //判斷資料
    var inputfname = document.getElementById("fname");
    inputfname.classList.remove("form-invalid");
    if (fname == '') {
        inputfname.classList.add("form-invalid");
        $(".invalid-feedback").css('display', 'block');
        return;
    }

    //判斷資料
    var inputfphone = document.getElementById("fphone");
    inputfphone.classList.remove("form-invalid");
    if (fphone == '') {
        inputfphone.classList.add("form-invalid");
        $(".invalid-feedback").css('display', 'block');
        return;
    }

    //判斷資料
    var inputfemail = document.getElementById("femail");
    inputfemail.classList.remove("form-invalid");
    if (femail == '') {
        inputfemail.classList.add("form-invalid");
        $(".invalid-feedback").css('display', 'block');
        return;
    }

    if (!isEmail(femail)) {
        inputfemail.classList.add("form-invalid");
        $(".invalid-feedback").css('display', 'block');
        $('#femail').val('');
        return;
    }

    //收集表單欄位資料
    var formData = {
        fname: fname,
        fphone: fphone,
        femail: femail,
        faddress: faddress
    }

    console.log(formData);
    let AjaxPost = new AjaxPostClass('/api/Customer', formData, callback_add_customer_fun);
    AjaxPost.do_ajax_post();

    function callback_add_customer_fun(ret) {

        console.log(ret);
        if (ret) {
            location.href = "/Home/List";
        }
    }
}

//檢查Mail格式Function
function isEmail(mail) {
    if (!mail) {
        console.log("mail是空的！")
        return mail
    }
    else {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(mail);
    }
}