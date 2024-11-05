"use strict";

type Listener<T> = (value: T) => void;

export class Observable<T> {
    private _listeners: Listener<T>[];
    protected _value: T;

    constructor(value: T) {
        this._listeners = [];
        this._value = value;
    }

    notify(): void {
        this._listeners.forEach(listener => listener(this._value));
    }

    subscribe(listener: Listener<T>): void {
        this._listeners.push(listener);
    }

    get value(): T {
        return this._value;
    }

    set value(val: T) {
        if (val !== this._value) {
            this._value = val;
            this.notify();
        }
    }
}

export class Computed<T> extends Observable<T> {
    constructor(value: () => T, deps: Observable<any>[]) {
        super(value());
        const listener = () => {
            this._value = value();
            this.notify();
        }
        deps.forEach(dep => dep.subscribe(listener));
    }

    get value(): T {
        return this._value;
    }

    set value(_: T) {
        throw new Error("Cannot set computed property");
    }
}

const bindValue = (input: HTMLInputElement, observable: Observable<string>): void => {
    input.value = observable.value;
    observable.subscribe(() => input.value = observable.value);
    input.onkeyup = () => observable.value = input.value;
};

const bindLabel = (label: HTMLLabelElement, observable: Observable<string>): void => {
    label.innerText = observable.value;
    observable.subscribe(() => label.innerText = observable.value);
}

export const bindControl = (control: HTMLElement, observable: Observable<string>): void => {
    if ('value' in control) {
        bindValue(control as HTMLInputElement, observable);
    } else {
        bindLabel(control as HTMLLabelElement, observable);
    }
}
