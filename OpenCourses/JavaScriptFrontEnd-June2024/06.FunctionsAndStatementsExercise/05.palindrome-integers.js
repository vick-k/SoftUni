function isPalindrome(numbers) {
    for (const number of numbers) {
        const str = number.toString();
        const reverseStr = str.split('').reverse().join('');

        if (str == reverseStr) {
            console.log('true');
        } else {
            console.log('false');
        }
    }
}

isPalindrome([123,323,421,121]);
