function sameNumbers(number) {
    let currentNumber = number;
    let isSame = true;
    let sum = 0;

    while (currentNumber > 0) {
        const lastDigit = currentNumber % 10;
        const beforeLastDigit = parseInt(currentNumber / 10) % 10;
        
        if (lastDigit != beforeLastDigit && beforeLastDigit != 0) {
            isSame = false;
        }

        sum += lastDigit;

        currentNumber = parseInt(currentNumber / 10);
    }

    console.log(isSame);
    console.log(sum);
}

sameNumbers(2222222);