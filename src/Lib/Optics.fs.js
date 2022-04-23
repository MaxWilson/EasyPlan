import { Union } from "../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { class_type, lambda_type, union_type } from "../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { uncurry, curry } from "../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";
import { some, value as value_1 } from "../ShiningSword/fable_modules/fable-library.3.6.2/Option.js";
import { mapIndexed, item, length } from "../ShiningSword/fable_modules/fable-library.3.6.2/List.js";

export class OpticResult$1 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Update", "Ignore"];
    }
}

export function OpticResult$1$reflection(gen0) {
    return union_type("Optics.OpticResult`1", [gen0], OpticResult$1, () => [[["Item", gen0]], []]);
}

export function OpticResult$1_map_7C4B0DD6(f) {
    return (_arg1) => {
        if (_arg1.tag === 0) {
            const v = _arg1.fields[0];
            return new OpticResult$1(0, f(v));
        }
        else {
            return new OpticResult$1(1);
        }
    };
}

export class Lens$2 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Lens"];
    }
}

export function Lens$2$reflection(gen0, gen1) {
    return union_type("Optics.Lens`2", [gen0, gen1], Lens$2, () => [[["Item", lambda_type(lambda_type(gen1, OpticResult$1$reflection(gen1)), lambda_type(gen0, OpticResult$1$reflection(gen0)))]]]);
}

export class Prism$2 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Prism"];
    }
}

export function Prism$2$reflection(gen0, gen1) {
    return union_type("Optics.Prism`2", [gen0, gen1], Prism$2, () => [[["Item", lambda_type(lambda_type(gen1, OpticResult$1$reflection(gen1)), lambda_type(gen0, OpticResult$1$reflection(gen0)))]]]);
}

export function Lens$2__get_d(this$) {
    const l = this$.fields[0];
    return curry(2, l);
}

export function Lens$2_op_QmarkEqualsGreater_1FE43D53(outer, inner) {
    return new Prism$2(0, uncurry(2, (f) => Lens$2__get_d(outer)((_arg1) => {
        if (_arg1 == null) {
            return new OpticResult$1(1);
        }
        else {
            const data = value_1(_arg1);
            const _arg2 = Lens$2__get_d(inner)(f)(data);
            if (_arg2.tag === 0) {
                const v = _arg2.fields[0];
                return new OpticResult$1(0, some(v));
            }
            else {
                return new OpticResult$1(1);
            }
        }
    })));
}

export function Lens$2_op_EqualsGreater_624073A0(outer, inner) {
    return new Lens$2(0, uncurry(2, (arg) => Lens$2__get_d(outer)(Lens$2__get_d(inner)(arg))));
}

export function Lens$2_op_EqualsGreater_Z57936B36(outer, inner) {
    return new Lens$2(0, uncurry(2, (arg) => Lens$2__get_d(outer())(Lens$2__get_d(inner)(arg))));
}

export function Lens$2_op_EqualsGreater_6063D74A(outer, inner) {
    return new Lens$2(0, uncurry(2, (arg) => Lens$2__get_d(outer)(Lens$2__get_d(inner())(arg))));
}

export function Lens$2_op_EqualsGreater_Z79C8B89F(outer, inner) {
    return new Prism$2(0, uncurry(2, (arg) => Lens$2__get_d(outer)(Prism$2__get_d(inner)(arg))));
}

export function Lens$2_op_EqualsGreater_4C1BA00B(outer, inner) {
    return new Prism$2(0, uncurry(2, (arg) => Lens$2__get_d(outer())(Prism$2__get_d(inner)(arg))));
}

export function Lens$2_op_EqualsGreater_7F47028B(outer, inner) {
    return new Prism$2(0, uncurry(2, (arg) => Lens$2__get_d(outer)(Prism$2__get_d(inner())(arg))));
}

export function Lens$2_create(get$, set$) {
    return new Lens$2(0, (f, s) => {
        const matchValue = f(get$(s));
        if (matchValue.tag === 1) {
            return new OpticResult$1(1);
        }
        else {
            const v = matchValue.fields[0];
            return new OpticResult$1(0, set$(v, s));
        }
    });
}

export function Prism$2__get_d(this$) {
    const l = this$.fields[0];
    return curry(2, l);
}

export function Prism$2_op_EqualsGreater_57591A80(outer, inner) {
    return new Prism$2(0, uncurry(2, (arg) => Prism$2__get_d(outer)(Prism$2__get_d(inner)(arg))));
}

export function Prism$2_op_EqualsGreater_7B8E8D2A(outer, inner) {
    return new Prism$2(0, uncurry(2, (arg) => Prism$2__get_d(outer())(Prism$2__get_d(inner)(arg))));
}

export function Prism$2_op_EqualsGreater_Z51D6A096(outer, inner) {
    return new Prism$2(0, uncurry(2, (arg) => Prism$2__get_d(outer)(Prism$2__get_d(inner())(arg))));
}

export function Prism$2_op_EqualsGreater_41121D71(outer, inner) {
    return new Prism$2(0, uncurry(2, (arg) => Prism$2__get_d(outer)(Lens$2__get_d(inner)(arg))));
}

export function Prism$2_op_EqualsGreater_Z60064615(outer, inner) {
    return new Prism$2(0, uncurry(2, (arg) => Prism$2__get_d(outer())(Lens$2__get_d(inner)(arg))));
}

export function Prism$2_op_EqualsGreater_Z4EF27555(outer, inner) {
    return new Prism$2(0, uncurry(2, (arg) => Prism$2__get_d(outer)(Lens$2__get_d(inner())(arg))));
}

export function Prism$2_create(get$, set$) {
    return new Prism$2(0, (f, s) => {
        const matchValue = get$(s);
        if (matchValue != null) {
            const v = value_1(matchValue);
            const matchValue_1 = f(v);
            if (matchValue_1.tag === 1) {
                return new OpticResult$1(1);
            }
            else {
                const v_1 = matchValue_1.fields[0];
                return new OpticResult$1(0, set$(v_1, s));
            }
        }
        else {
            return new OpticResult$1(1);
        }
    });
}

export class Operations {
    constructor() {
    }
}

export function Operations$reflection() {
    return class_type("Optics.Operations", void 0, Operations);
}

export function Operations_read_Z4EEE036B(_arg1) {
    const lens = _arg1.fields[0];
    return (state) => {
        let retval = null;
        lens((v) => {
            retval = v;
            return new OpticResult$1(1);
        }, state);
        return retval;
    };
}

export function Operations_read_5566C854(_arg2) {
    const prism = _arg2.fields[0];
    return (state) => {
        let retval = void 0;
        prism((v) => {
            retval = some(v);
            return new OpticResult$1(1);
        }, state);
        return retval;
    };
}

export function Operations_over_Z4EEE036B(_arg3) {
    const l = _arg3.fields[0];
    return (f) => ((state) => {
        const matchValue = l((arg) => (new OpticResult$1(0, f(arg))), state);
        if (matchValue.tag === 1) {
            throw (new Error("Shouldn\u0027t ever happen: over failed to return a value"));
        }
        else {
            const v = matchValue.fields[0];
            return v;
        }
    });
}

export function Operations_over_5566C854(_arg4) {
    const prism = _arg4.fields[0];
    return (f) => ((state) => {
        const matchValue = prism((arg) => (new OpticResult$1(0, f(arg))), state);
        if (matchValue.tag === 1) {
            return state;
        }
        else {
            const v = matchValue.fields[0];
            return v;
        }
    });
}

export function Operations_write_Z4EEE036B(lens) {
    return (value) => ((state) => Operations_over_Z4EEE036B(lens)((_arg1) => value)(state));
}

export function Operations_write_5566C854(prism) {
    const prism_1 = prism;
    return (value) => ((state) => Operations_over_5566C854(prism_1)((_arg2) => value)(state));
}

export function Operations_writeSome_Z293E5EFA(lens) {
    return (value) => ((state) => Operations_over_Z4EEE036B(lens)((_arg3) => some(value))(state));
}

export function Operations_writeSome_15F2A9C7(prism) {
    return (value) => ((state) => Operations_over_5566C854(prism)((_arg4) => some(value))(state));
}

export function Operations_read_Z4CCDA781(lens) {
    return Operations_read_Z4EEE036B(lens());
}

export function Operations_read_Z53E97242(prism) {
    return Operations_read_5566C854(prism());
}

export function Operations_over_Z4CCDA781(lens) {
    return Operations_over_Z4EEE036B(lens());
}

export function Operations_over_Z53E97242(prism) {
    return Operations_over_5566C854(prism());
}

export function Operations_write_Z4CCDA781(lens) {
    return Operations_write_Z4EEE036B(lens());
}

export function Operations_write_Z53E97242(prism) {
    return Operations_write_5566C854(prism());
}

export function Operations_writeSome_Z1EE5F354(lens) {
    return Operations_writeSome_Z293E5EFA(lens());
}

export function Tuple2_fst_() {
    return Lens$2_create((tuple) => tuple[0], (v, st) => [v, st[1]]);
}

export function Tuple2_snd_() {
    return Lens$2_create((tuple) => tuple[1], (v, st) => [st[0], v]);
}

export function Option_some_() {
    return Prism$2_create((x) => x, (v, d) => some(v));
}

export function Option_some__() {
    return Lens$2_create((option) => value_1(option), (v, d) => some(v));
}

export function List_nth_(n) {
    return Prism$2_create((l) => {
        if (n >= length(l)) {
            return void 0;
        }
        else {
            return some(item(n, l));
        }
    }, (v, d) => mapIndexed((i, x) => {
        if (i === n) {
            return v;
        }
        else {
            return x;
        }
    }, d));
}

export function List_nth__(n) {
    return Lens$2_create((list) => item(n, list), (v, d) => mapIndexed((i, x) => {
        if (i === n) {
            return v;
        }
        else {
            return x;
        }
    }, d));
}

//# sourceMappingURL=Optics.fs.js.map
