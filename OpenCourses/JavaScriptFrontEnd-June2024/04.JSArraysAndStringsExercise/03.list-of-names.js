function listOfNames(arr) {
    arr.sort((a, b) => a.localeCompare(b));
    let result = '';

    for (let i = 1; i <= arr.length; i++) {
        result += `${i}.${arr[i - 1]} \n`;
    }

    console.log(result.trimEnd());
}

listOfNames(['John', 'Bob', 'Christina', 'Ema']);
