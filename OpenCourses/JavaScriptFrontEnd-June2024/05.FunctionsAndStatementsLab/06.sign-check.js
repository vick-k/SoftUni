function signCheck(numOne, numTwo, numThree) {
    const nums = [numOne, numTwo, numThree];
    let negativeNums = [];

    for (const num of nums) {
        if (num < 0) {
            negativeNums.push(num);
        }
    }

    if (negativeNums.length % 2 != 0) {
        console.log('Negative');
    } else {
        console.log('Positive');
    }
}

signCheck(5, 12, -15);
