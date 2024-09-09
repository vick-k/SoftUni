function movies(inputCommands) {
    let moviesList = [];

    for (const commandInfo of inputCommands) {
        if (commandInfo.startsWith('addMovie')) {
            const movieTitle = commandInfo.split('addMovie ')[1];
            let newMovie = {
                name: movieTitle,
                director: '',
                date: '',
            };

            moviesList.push(newMovie);
            continue;
        }

        if (commandInfo.includes('directedBy')) {
            let [name, director] = commandInfo.split(' directedBy ');
            const currentMovie = moviesList.find(movie => movie.name == name);

            if (currentMovie) {
                currentMovie.director = director;
            }

            continue;
        }

        if (commandInfo.includes('onDate')) {
            let [name, date] = commandInfo.split(' onDate ');
            const currentMovie = moviesList.find(movie => movie.name == name);

            if (currentMovie) {
                currentMovie.date = date;
            }

            continue;
        }
    }

    moviesList.forEach(movie => {
        if (movie.name != '' && movie.date != '' && movie.director != '') {
            console.log(JSON.stringify(movie));
        }
    });
}

movies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen',
]);
