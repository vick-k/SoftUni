function arrayRotation(arr, count) {
    const actualRotations = count % arr.length;

    for (let i = 0; i < actualRotations; i++) {
        const firstElement = arr.shift();
        arr.push(firstElement);
    }

    console.log(arr.join(' '));
}

arrayRotation([2, 4, 15, 31], 5);
