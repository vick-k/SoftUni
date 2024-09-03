function hashtagExtract(text) {
    const regex = /#[A-Za-z]+\b/gm;
    const matches = text.match(regex);

    console.log(matches.join('\n').replaceAll('#', ''));
}

hashtagExtract('Nowadays everyone uses # to tag a #special word in #socialMedia');
