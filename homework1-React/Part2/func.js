const girlsPowerFunc = (n) => (n/2) +3;

let result;
const girlsPower = (...arr) =>{

    arr.forEach(element =>{
        result = arr.map(element => girlsPowerFunc(element));
    });
    return result;

}

array = [2,3,4];
console.log(girlsPower(...array));