const EventEmitter = require('events');

class MyEmitter extends EventEmitter {}

const myEmitter = new MyEmitter();
myEmitter.on('waterFull', () => {
  console.log('please switch off the motter !');
  setTimeout(() => {
    console.log('gentle reminder#### please switch off the motter !');
  }, 3000);
});
myEmitter.on('tankEmptity', () => {
    console.log('please switch on the motter !');
    setTimeout(() => {
      console.log('gentle reminder#### please switch on the motter !');
    }, 3000);
  });
module.exports = myEmitter;