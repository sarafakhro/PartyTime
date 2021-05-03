function wrongEmail() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Your e-mail does not exist in our system!!',
        footer: '<a href="SignUp.aspx">Sign up?</a>'
    })
}

function emptyFields() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Please, fill in all the fields!'
    })
}


function mustLogin() {
    Swal.fire({
        icon: 'info',
        title: 'Oops...',
        text: 'You must be logged to continue!',
        footer: '<a href="LogIn.aspx">Log In?</a>'
    })
}

function logOut() {
    Swal.fire('You will be logged out!')
}

function sendMessage() {
    Swal.fire(
        'Thank you!',
        'Your message has been sent!',
        'success'
    )
}

function wrongEmail_Pass() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Wrong e-mail or password!',
    })
}

function emailExist() {
    Swal.fire({
        icon: 'info',
        title: 'Oops...',
        text: 'Email alredy exist!',
        footer: '<a href="LogIn.aspx">Log In?</a>'
    })
}

function usernameExist() {
    Swal.fire({
        icon: 'info',
        title: 'Oops...',
        text: 'Username alredy exist!',
        footer: '<a href="LogIn.aspx">Log In?</a>'
    })
}
function doneInput() {
    Swal.fire({
        icon: 'info',
        title: 'Oops...',
        text: 'Your parameters has been saved, we are generating suggestions for you.\nYou can find them att my planning page!',
        footer: '<a href="myPlanning.aspx">My planning</a>'
    })
}


function doneAdminInput() {
    Swal.fire({
        icon: 'info',
        title: 'Oops...',
        text: 'Your parameters has been saved!'
    })
}

function wrongExtesnion() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Wrong picture exstension!',
    })
}