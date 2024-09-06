function passwordValidate(password) {
    function checkLength(currentPass) {
        return currentPass.length >= 6 && currentPass.length <= 10;
    }

    function checkSymbols(currentPass) {
        const regex = /^[A-Za-z0-9]+$/gm;
        
        return regex.test(currentPass);
    }

    function checkMinDigits(currentPass) {
        const regex = /[\d]{2,}/gm;

        return regex.test(currentPass);
    }

    let isValid = true;

    if (!checkLength(password)) {
        isValid = false;
        console.log('Password must be between 6 and 10 characters');
    }
    
    if (!checkSymbols(password)) {
        isValid = false;
        console.log('Password must consist only of letters and digits');
    }
    
    if (!checkMinDigits(password)) {
        isValid = false;
        console.log('Password must have at least 2 digits');
    } 
    
    if (isValid) {
        console.log('Password is valid');
    }
}

passwordValidate('logIn');
passwordValidate('MyPass123');
passwordValidate('Pa$s$s');
