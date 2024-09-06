function perfectNumber(number) {
    let divisors = [];

    for (let i = 1; i < number; i++) {
        if (number % i == 0) {
            divisors.push(i);
        }
    }

    let sum = 0;
    divisors.forEach(number => sum += number);

    if (sum == number && number > 0) {
        console.log('We have a perfect number!');
    } else {
        console.log("It's not so perfect.");
    }
}

perfectNumber(6);
perfectNumber(28);
perfectNumber(1236498);
