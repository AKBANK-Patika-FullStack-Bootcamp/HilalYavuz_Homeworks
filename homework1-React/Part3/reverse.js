
const firstMethod = (name) =>{
    let result="";
    for(let i = name.length-1; i >= 0; i--){
        result += name.charAt(i);
    }
    return result;
};

console.log("First method:",firstMethod("hilal"));

const secondMethod = (name) =>{
    let result = name.split("").reverse().join("");
    return result;

};

console.log("Second method:",secondMethod("hilal"));


const thirdMethod = (name) =>{

    if(name==""){
        return "";
    }else{
        return thirdMethod(name.substr(1)) + name.charAt(0);
    }

};

console.log("Third method:",thirdMethod("hilal"));


const fourthMethod = (name) =>{
    let result = [...name].reduce((acc,curr) => curr+acc);
    return result;


};

console.log("Fourth method:",fourthMethod("hilal"));