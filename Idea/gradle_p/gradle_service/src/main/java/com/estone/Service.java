package com.estone;

public class Service {
    public void sayHi() {
        Util.sayHi();
    }

    public static void main(String[] args) {
        Service service = new Service();
        service.sayHi();
    }
}

