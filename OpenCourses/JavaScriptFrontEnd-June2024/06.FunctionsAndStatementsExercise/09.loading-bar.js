function loadingBar(percent) {
    const maxSymbols = 10;
    const percentageSymbolCount = percent / 10;
    const dotSymbolCount = maxSymbols - percentageSymbolCount;

    if (percent == 100) {
        console.log('100% Complete!');
        console.log(`[${'%'.repeat(maxSymbols)}]`);
    } else {
        console.log(`${percent}% [${'%'.repeat(percentageSymbolCount)}${'.'.repeat(dotSymbolCount)}]`);
        console.log('Still loading...');
    }
}

loadingBar(0);
loadingBar(30);
loadingBar(50);
loadingBar(100);
