
const kopek = require("./kopek");

const kopekBakim = require("./kopekBakimUtility");


const {isim, kilo, boy} = kopek;
console.log("kopek isim:", isim);
console.log("kopek boy:",boy);
kopekBakim.kopegiTemizle();
const ilgiSaati = kilo*kopekBakim.kopekBakimSaati;
console.log("kopek ilgi saati:", ilgiSaati);


