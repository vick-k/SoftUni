function oddAndEvenSum(number) {
    let numbers = [];
    let currentNumber = number;

    while (currentNumber > 0) {
        const lastDigit = currentNumber % 10;
        numbers.push(lastDigit);

        currentNumber = parseInt(currentNumber / 10);
    }

    let oddSum = 0;
    let evenSum = 0;

    numbers.forEach(number => {
        if (number % 2 == 0) {
            evenSum += number;
        } else {
            oddSum += number;
        }
    });

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

oddAndEvenSum(1000435);
