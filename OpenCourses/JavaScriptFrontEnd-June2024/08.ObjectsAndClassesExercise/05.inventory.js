function inventory(inputInfo) {
    let heroesData = [];

    inputInfo.forEach(entry => {
        let [heroName, heroLevel, items] = entry.split(' / ');

        const newHero = {
            name: heroName,
            level: heroLevel,
            items,
        };

        heroesData.push(newHero);
    });

    const sortedHeroes = heroesData.slice().sort((a, b) => a.level - b.level);

    sortedHeroes.forEach(hero =>
        console.log(`Hero: ${hero.name}\nlevel => ${hero.level}\nitems => ${hero.items}`)
    );
}

inventory([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara',
]);
