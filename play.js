const person = {
    name: 'Max',
    age: 29,
    greet() {
      console.log('Hi, I am ' + this.name);
    }
  };
  
  //const copiedPerson = { ...person };
  //console.log(copiedPerson);
  
  const hobbies = ['Sports', 'Cooking'];
  // for (let hobby of hobbies) {
  //     console.log(hobby);
  // }
  // console.log(hobbies.map(hobby => 'Hobby: ' + hobby));
  // console.log(hobbies);
  //const copiedArray = [...hobbies];
// const copiedArray=hobbies.slice();
  const copiedArray=hobbies.slice();
  //hobbies.copyWithin(copiedArray);
  //console.log(copiedArray);
  copiedArray[0]="sachin";
  console.log(copiedArray);
  console.log(hobbies);
  
  const toArray = (...args) => {
    return args;
  };
  
  console.log(toArray(1, 2, 3, 4));
  