using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Metrics{

    public float speed = 5.0f;
    public float range = 4.0f;
    public float accepted_error = 1.0f;

    public Metrics(){}

    static Metrics CreateMetrics(params Func<float, Action<Metrics>>[] functional_args){
        Metrics m = new Metrics();
        foreach(Action f in functional_args){
            f(m);
        }
        return m;
    }

    static Action<Metrics> with_speed(float _s){
        return (m) => m.speed = _s;
    }

    static Action<Metrics> with_range(float _r){
        return (m) => m.range = _r;
    }

    static Action<Metrics> with_accepted_error(float _a){
        return (m) => m.accepted_error = _a;
    }

}

Metrics m = CreateMetrics(Metrics.with_accepted_error(10.0f));


public Action<Metrics> with_accepted_error(float _a){
    if (_a < 11.0f) && (_a > 4.0f){
        return (m) => m.accepted_error = _a;
    }
    }