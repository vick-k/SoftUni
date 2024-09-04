function simpleCalculator(numberOne, numberTwo, operator) {
    switch (operator) {
        case 'multiply':
            calculate = (a, b) => a * b;
            break;
        case 'divide':
            calculate = (a, b) => a / b;
            break;
        case 'add':
            calculate = (a, b) => a + b;
            break;
        case 'subtract':
            calculate = (a, b) => a - b;
            break;
    }

    const result = calculate(numberOne, numberTwo);

    console.log(result);
}

simpleCalculator(5, 5, 'multiply');
