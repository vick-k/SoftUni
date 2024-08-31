function vacation(peopleCount, groupType, day) {
    const isFriday = day == 'Friday';
    const isSaturday = day == 'Saturday';
    const isSunday = day == 'Sunday';

    const isStudents = groupType == 'Students';
    const isBusiness = groupType == 'Business';
    const isRegular = groupType == 'Regular';
    
    let totalPriceWithoutDiscount = 0;

    if (isFriday) {
        if (isStudents) {
            totalPriceWithoutDiscount = peopleCount * 8.45;
        } else if (isBusiness) {
            totalPriceWithoutDiscount = peopleCount * 10.90;
        } else if (isRegular) {
            totalPriceWithoutDiscount = peopleCount * 15;
        }
    } else if (isSaturday) {
        if (isStudents) {
            totalPriceWithoutDiscount = peopleCount * 9.80;
        } else if (isBusiness) {
            totalPriceWithoutDiscount = peopleCount * 15.60;
        } else if (isRegular) {
            totalPriceWithoutDiscount = peopleCount * 20;
        }
    } else if (isSunday) {
        if (isStudents) {
            totalPriceWithoutDiscount = peopleCount * 10.46;
        } else if (isBusiness) {
            totalPriceWithoutDiscount = peopleCount * 16;
        } else if (isRegular) {
            totalPriceWithoutDiscount = peopleCount * 22.50;
        }
    }

    let totalPrice = totalPriceWithoutDiscount;

    if (isStudents && peopleCount >= 30) {
        totalPrice *= 0.85;
    } else if (isBusiness && peopleCount >= 100) {
        if (isFriday) {
            totalPrice = (peopleCount - 10) * 10.90;
        } else if (isSaturday) {
            totalPrice = (peopleCount - 10) * 15.60;
        } else if (isSunday) {
            totalPrice = (peopleCount - 10) * 16;
        }
    } else if (isRegular && (peopleCount >= 10 && peopleCount <= 20)) {
        totalPrice *= 0.95;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

vacation(30, 'Students', 'Sunday');