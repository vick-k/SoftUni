function factorialDivision(numOne, numTwo) {
    function factorial(a) {
        if (a < 1) {
            return 1;
        }

        return a * factorial(a - 1)
    }

    const firstFactorial = factorial(numOne);
    const secondFactorial = factorial(numTwo);
    const result = firstFactorial / secondFactorial;

    console.log(result.toFixed(2));
}

factorialDivision(6, 2);
