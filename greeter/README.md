## Purpose

Learn TDD and Emergent Design and Pair Programming on katas.

## Setup

### Prerequisites
* [Visual Studio Code](https://code.visualstudio.com) 
* [Node](https://nodejs.org/en)


Install the remote collaboration plugin:
    - VS Code: install [Live Share](https://marketplace.visualstudio.com/items?itemName=MS-vsliveshare.vsliveshare)


### Environment setup

1. Fork repo. Click the Fork button at the top right. See [forking a repository](https://docs.github.com/en/get-started/quickstart/fork-a-repo#forking-a-repository) for further details.

2. Clone your forked repo
```
git clone git@github.com:<username>/katas.git
```

3. Change directory
```
cd greeter
```

4. Open in IDE
```
code .
```

### Installation
Ensure you have installed npm packages
```
npm install
```
or
```
yarn install
```

## Usage

### Run tests
```
npm test
```


### Run tests continuously
```
npm run testw
```



#### Before you start:
* **Try not to read ahead.**
* **Do one task at a time. The trick is to learn to work incrementally.**
* **Remember the Three Rules of TDD:**
  1. You are not allowed to write any production code unless it is to make a failing unit test pass.
  2. You are not allowed to write any more of a unit test than is sufficient to fail; and compilation failures are failures.
  3. You are not allowed to write any more production code than is sufficient to pass the one failing unit test.

This kata introduces the red-green-refactor workflow of TDD via ping-pong or driver/navigator pairing.

## Pairing 
- **Ping pong**
    - One developer writes a failing test, then the other writes the code to make the test pass. Afterward, roles switch: the second developer writes the next test, and the first implements the code.
- **Driver/navigator** 
    -  One developer (the "driver") writes code while the other (the "navigator") reviews each line, thinks strategically, and provides guidance or suggestions. The roles gets switched after each acceptance criteria or in fixed intervals.
    
### Greeter

1. Write a `Greeter` class with `greet` instance method. Initially, the method receives a `name` as input and outputs `Hello <name>`.
2. `greet` trims the input
3. `greet` capitalizes the first letter of the name
4. `greet` returns `Good morning <name>` when the time is 06:00-12:00
5. `greet` returns `Good evening <name>` when the time is 18:00-22:00
6. `greet` returns `Good night <name>` when the time is 22:00-06:00
7. `greet` logs on console every time it is run