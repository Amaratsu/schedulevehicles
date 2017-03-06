//Authorization
var user = {
    email: null,
    password: null
};

var tempValue;

function send() {
    $.ajax({
            url: '/Home/Authorization',
            type: 'POST',
            data: user
        })
        .done(function(msg) {
            if (msg === 'fieldError') {
                console.log(msg);
                showForm();
            } else if (msg === 'errorAthorization') {
                console.log(msg);
                showForm();
            } else {
                console.log(msg);
                tempValue = msg;
                hideForm();       
                localStorage.setItem("emailAuth", user.email);
                localStorage.setItem("passwordAuth", user.password);
            }

        })
        .always(function() {

        });
};

function autoAuth() {
    if (localStorage.getItem("emailAuth") != null && localStorage.getItem("passwordAuth") != null) {
        user.email = localStorage.getItem("emailAuth");
        user.password = localStorage.getItem("passwordAuth");
        send();
    } else if ((localStorage.getItem("emailAuth") == null && localStorage.getItem("passwordAuth") == null)) {
        user.email = $('#emailAuth').val();
        user.password = $('#passwordAuth').val();
        send();
    }  
}

function auth() {
    user.email = $('#emailAuth').val();
    user.password = $('#passwordAuth').val();
    send();
}

function logout() {
    showForm();
    localStorage.clear();  
}



var hideForm = function() {
    $('#stateAuth').css('display', 'none');
    $('#firstAndLastName').text(tempValue);
    $('#stateUser').css('display', 'block');
};

var showForm = function() {  
    $('#stateUser').css('display', 'none');
    $('#stateAuth').css('display', 'block');
    $("#emailAuth").val(localStorage.getItem("emailAuth"));
    $("#passwordAuth").val(localStorage.getItem("passwordAuth"));
};