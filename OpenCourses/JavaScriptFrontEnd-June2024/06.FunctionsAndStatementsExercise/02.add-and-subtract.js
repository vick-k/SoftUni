function addAndSubtract(numOne, numTwo, numThree) {
    function sum(a, b) {
        return a + b;
    }

    function subtract(a, b) {
        return a - b;
    }

    sumResult = sum(numOne, numTwo);
    subtractResult = subtract(sumResult, numThree);

    return subtractResult;
}

addAndSubtract(23, 6, 10);
