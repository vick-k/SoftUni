function printSongs(arr) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let songs = [];
    const songsCount = arr[0];

    for (let i = 1; i <= songsCount; i++) {
        let [typeList, name, time] = arr[i].split('_');
        let song = new Song(typeList, name, time);
        songs.push(song);
    }

    const requestedTypeList = arr[arr.length - 1];

    if (requestedTypeList == 'all') {
        songs.forEach(song => console.log(song.name));
        return;
    }

    songs.forEach(song => {
        if (song.typeList == requestedTypeList) {
            console.log(song.name);
        }
    });
}

printSongs([3,
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'favourite']);
