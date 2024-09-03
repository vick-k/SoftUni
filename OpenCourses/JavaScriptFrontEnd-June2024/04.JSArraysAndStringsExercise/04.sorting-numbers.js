function sortingNumbers(arr) {
    let sortedArr = arr.slice().sort((a, b) => a - b);
    let outputArr = [];

    for (let i = 0; i < arr.length; i++) {
        if (i % 2 == 0) {
            outputArr.push(sortedArr.shift());
        } else {
            outputArr.push(sortedArr.pop());
        }
    }

    return outputArr;
}

sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);
