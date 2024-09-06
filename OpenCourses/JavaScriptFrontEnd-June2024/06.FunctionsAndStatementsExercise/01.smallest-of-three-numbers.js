function smallestNumber(numOne, numTwo, numThree) {
    function findTheSmallerNumber(a, b, c) {
        return Math.min(a, b, c);
    }

    console.log(findTheSmallerNumber(numOne, numTwo, numThree));
}

smallestNumber(2, 5, 3);
