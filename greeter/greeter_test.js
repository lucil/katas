'use strict';

const Greeter = require('./greeter.js')

beforeEach(() => {
    greeter = new Greeter();
});

describe('Greeter basic formatting', () => {
    test('prints Hello <name>', () => {
        expect(greeter.greet('World')).toBe('Hello World');
    });

    test('trims the input name', () => {
        expect(greeter.greet('   Alice   ')).toBe('Hello Alice');
    });

    test('capitalizes first letter of the name', () => {
        expect(greeter.greet('alice')).toBe('Hello Alice');
    });
});

describe('Greeter time-based greetings', () => {
    test.each([
        ['Good morning', 'Bob', '2022-01-01T08:30:00'],
        ['Good evening', 'Bob', '2022-01-01T19:30:00'],
        ['Good night', 'Eve', '2022-01-01T23:15:00'],
        ['Good night', 'Eve', '2022-01-01T03:30:00'],
        ['Good night', 'Eve', '2022-01-01T22:00:00'],
        ['Hello', 'Eve', ''],
    ])('%s for name %s at %s', (expectedGreeting, name, dateStr) => {
        const date = new Date(dateStr);
        expect(greeter.greet(name, date)).toBe(`${expectedGreeting} ${name}`);
    });
});

describe('Greeter logging', () => {
    let originalLog;
    beforeEach(() => {
        originalLog = console.log;
        console.log = jest.fn();
    });
    afterEach(() => {
        console.log = originalLog;
    });

    test('logs to console every time it is run', () => {
        greeter.greet('alice');
        expect(console.log).toHaveBeenCalled();

        greeter.greet('bob');
        expect(console.log).toHaveBeenCalledTimes(2);

        expect(console.log).toHaveBeenCalledWith('Hello Alice');
        expect(console.log).toHaveBeenCalledWith('Hello Bob');
    });
});