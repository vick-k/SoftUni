function sum(number) {
    let currentNumber = number;
    let sum = 0;

    while (currentNumber > 0) {
        lastDigit = currentNumber % 10;
        sum += lastDigit;
        currentNumber = parseInt(currentNumber / 10);
    }

    console.log(sum);
}

sum(245678);