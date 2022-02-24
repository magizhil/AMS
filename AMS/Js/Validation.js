function ValidateEmail(email) {
    // Validate email format
    var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    return expr.test(email);
}

function ValidatePhno(phno) {
    // Validate phone format
    //alert(phno);
    var expr = /^\d*(?:\.\d{1,2})?$/;;
    return expr.test(phno);
};



