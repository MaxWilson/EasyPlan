import { toString, Record } from "../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { int32_type, record_type, bool_type, list_type, tuple_type, option_type, string_type } from "../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { RollSpec_create_4F7761DC, RollSpec_create_Z37302880, Universal_Detail$2__get_isADND, RollSpec__roll, ADND2nd_CharacterSheet, Universal_Detail$2__map2e_Z1FC644CA, DND5e_CharacterSheet, Universal_Detail$2__map5e_Z1D9544EA, DND5e_statBonus, Universal_Detail$2$reflection, DND5e_CharacterSheet$reflection, ADND2nd_CharacterSheet$reflection, RollSpec$reflection } from "./Character.fs.js";
import { FightResult, State_get_fresh, FlagsProperty$1__SetAllM, State$reflection, FightResult$reflection } from "./Ribbit/Types.fs.js";
import { ofArray, replicate, collect, append, sum, length, map as map_1, cons, fold, singleton, empty } from "../ShiningSword/fable_modules/fable-library.3.6.2/List.js";
import { chooseRandomExponentialDecay, chooseRandom, StateMonad_StateBuilder__For_4BCC29DA, StateMonad_stateChange, StateMonad_StateBuilder__Return_1505, StateMonad_StateBuilder__Bind_3179, StateMonad_StateBuilder__Delay_Z38F4EA44, StateMonad_runNoResult } from "./Common.fs.js";
import { comparePrimitives, uncurry } from "../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";
import { Treasure_treasureValue, weaponDamageP, toHitP, numberOfAttacksP, acP, hpP, addCharacterToRoster } from "./Ribbit/Operations.fs.js";
import { sumBy } from "../ShiningSword/fable_modules/fable-library.3.6.2/Array.js";
import { fightUntilFixedPoint as fightUntilFixedPoint_1, monsterKinds as monsterKinds_1, createByName as createByName_1, traitsP, initBonusP } from "./Ribbit/Rules5e.fs.js";
import { map } from "../ShiningSword/fable_modules/fable-library.3.6.2/Set.js";
import { FSharpMap__get_Item, tryFind } from "../ShiningSword/fable_modules/fable-library.3.6.2/Map.js";
import { fightOneRound, createByName, monsterKinds } from "./Ribbit/Rules2e.fs.js";
import { value as value_2, map as map_2 } from "../ShiningSword/fable_modules/fable-library.3.6.2/Option.js";

export class Encounter extends Record {
    constructor(description, monsters, inLair) {
        super();
        this.description = description;
        this.monsters = monsters;
        this.inLair = inLair;
    }
}

export function Encounter$reflection() {
    return record_type("Domain.Adventure.Encounter", [], Encounter, () => [["description", string_type], ["monsters", list_type(tuple_type(string_type, option_type(RollSpec$reflection())))], ["inLair", bool_type]]);
}

export function Encounter_wandering(description, monsters) {
    return new Encounter(description, monsters, false);
}

export function Encounter_lair(description, monsters) {
    return new Encounter(description, monsters, true);
}

export class OngoingEncounter extends Record {
    constructor(monsters, outcome, inLair) {
        super();
        this.monsters = monsters;
        this.outcome = outcome;
        this.inLair = inLair;
    }
}

export function OngoingEncounter$reflection() {
    return record_type("Domain.Adventure.OngoingEncounter", [], OngoingEncounter, () => [["monsters", list_type(tuple_type(string_type, int32_type))], ["outcome", FightResult$reflection()], ["inLair", bool_type]]);
}

export class AdventureSpec extends Record {
    constructor(description, encounters, allies, bonusXP, bonusGP) {
        super();
        this.description = description;
        this.encounters = encounters;
        this.allies = allies;
        this.bonusXP = (bonusXP | 0);
        this.bonusGP = (bonusGP | 0);
    }
}

export function AdventureSpec$reflection() {
    return record_type("Domain.Adventure.AdventureSpec", [], AdventureSpec, () => [["description", string_type], ["encounters", list_type(Encounter$reflection())], ["allies", list_type(Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection()))], ["bonusXP", int32_type], ["bonusGP", int32_type]]);
}

export function AdventureSpec_fresh(description, encounters) {
    return new AdventureSpec(description, encounters, empty(), 0, 0);
}

export class AdventureState extends Record {
    constructor(mainCharacter, allies, currentEncounter, scheduledEncounters, ribbit) {
        super();
        this.mainCharacter = mainCharacter;
        this.allies = allies;
        this.currentEncounter = currentEncounter;
        this.scheduledEncounters = scheduledEncounters;
        this.ribbit = ribbit;
    }
}

export function AdventureState$reflection() {
    return record_type("Domain.Adventure.AdventureState", [], AdventureState, () => [["mainCharacter", Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection())], ["allies", list_type(Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection()))], ["currentEncounter", option_type(OngoingEncounter$reflection())], ["scheduledEncounters", list_type(Encounter$reflection())], ["ribbit", State$reflection()]]);
}

export function loadCharacters(characters, adventureState) {
    const addCharacter = (state$0027, ribbit) => {
        let char_1, char;
        return StateMonad_runNoResult(state$0027, (ribbit.tag === 1) ? ((char_1 = ribbit.fields[0], StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, addCharacterToRoster(char_1.name), uncurry(2, (_arg8) => {
            const id_1 = _arg8 | 0;
            return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, hpP["Domain.Ribbit.Property`1.SetM6570C449"](id_1, sumBy((tupledArg_2) => {
                const lhs_1 = tupledArg_2[0] | 0;
                const rhs_1 = tupledArg_2[1] | 0;
                return (lhs_1 + rhs_1) | 0;
            }, char_1.hp, {
                GetZero: () => 0,
                Add: (x_2, y_2) => (x_2 + y_2),
            })), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, acP["Domain.Ribbit.Property`1.SetM6570C449"](id_1, char_1.ac), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, numberOfAttacksP["Domain.Ribbit.Property`1.SetM6570C449"](id_1, 1), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, toHitP["Domain.Ribbit.Property`1.SetM6570C449"](id_1, char_1.toHit), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, weaponDamageP["Domain.Ribbit.Property`1.SetM6570C449"](id_1, singleton(char_1.damage)), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, initBonusP["Domain.Ribbit.Property`1.SetM6570C449"](id_1, DND5e_statBonus(char_1.Dex)), uncurry(2, () => {
                let tupledArg_3;
                return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (tupledArg_3 = [id_1, map((value_1) => toString(value_1), char_1.traits.summary, {
                    Compare: (x_3, y_3) => comparePrimitives(x_3, y_3),
                })], (arg10_1) => FlagsProperty$1__SetAllM(traitsP, tupledArg_3[0], tupledArg_3[1], arg10_1)), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange)));
            }))))))))))));
        })))))) : ((char = ribbit.fields[0], StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, addCharacterToRoster(char.name), uncurry(2, (_arg1) => {
            const id = _arg1 | 0;
            return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, hpP["Domain.Ribbit.Property`1.SetM6570C449"](id, sumBy((tupledArg) => {
                const lhs = tupledArg[0] | 0;
                const rhs = tupledArg[1] | 0;
                return (lhs + rhs) | 0;
            }, char.hp, {
                GetZero: () => 0,
                Add: (x, y) => (x + y),
            })), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, acP["Domain.Ribbit.Property`1.SetM6570C449"](id, char.ac), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, numberOfAttacksP["Domain.Ribbit.Property`1.SetM6570C449"](id, char.attacks), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, toHitP["Domain.Ribbit.Property`1.SetM6570C449"](id, char.toHitBonus), uncurry(2, () => StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, weaponDamageP["Domain.Ribbit.Property`1.SetM6570C449"](id, singleton(char.damage)), uncurry(2, () => {
                let tupledArg_1;
                return StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, (tupledArg_1 = [id, map((value) => toString(value), char.traits.summary, {
                    Compare: (x_1, y_1) => comparePrimitives(x_1, y_1),
                })], (arg10) => FlagsProperty$1__SetAllM(traitsP, tupledArg_1[0], tupledArg_1[1], arg10)), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange)));
            }))))))))));
        })))))));
    };
    return new AdventureState(adventureState.mainCharacter, adventureState.allies, adventureState.currentEncounter, adventureState.scheduledEncounters, fold(addCharacter, adventureState.ribbit, characters));
}

export function downtime(sheet) {
    return new AdventureState(sheet, empty(), void 0, empty(), State_get_fresh());
}

export function embark(spec, sheet) {
    return loadCharacters(cons(sheet, spec.allies), new AdventureState(sheet, spec.allies, void 0, spec.encounters, State_get_fresh()));
}

export function finishAdventure(spec, state) {
    const mainCharacter$0027 = Universal_Detail$2__map5e_Z1D9544EA(Universal_Detail$2__map2e_Z1FC644CA(state.mainCharacter, (char) => (new ADND2nd_CharacterSheet(char.id, char.name, char.origin, char.sex, char.Str, char.Dex, char.Con, char.Int, char.Wis, char.Cha, char.exceptionalStrength, char.originalRolls, char.hp, char.ac, char.attacks, char.toHitBonus, char.damage, char.xp + (1 * spec.bonusXP), char.levels, char.traits, char.wealth + (1 * spec.bonusGP)))), (char_1) => (new DND5e_CharacterSheet(char_1.id, char_1.name, char_1.origin, char_1.sex, char_1.Str, char_1.Dex, char_1.Con, char_1.Int, char_1.Wis, char_1.Cha, char_1.originalRolls, char_1.hp, char_1.ac, char_1.toHit, char_1.damage, char_1.xp + (1 * spec.bonusXP), char_1.levels, char_1.traits, char_1.wealth + (1 * spec.bonusGP))));
    const msg = ((spec.bonusXP > 0) && (spec.bonusGP > 0)) ? (`You gain an extra ${spec.bonusXP} XP and ${spec.bonusGP} gold pieces for completing the adventure!`) : ((spec.bonusXP > 0) ? (`You gain an extra ${spec.bonusXP} XP for completing the adventure!`) : ((spec.bonusGP > 0) ? (`You gain an extra ${spec.bonusGP} gold pieces for completing the adventure!`) : "Congratulations on a successful adventure!"));
    return [msg, new AdventureState(mainCharacter$0027, state.allies, state.currentEncounter, state.scheduledEncounters, state.ribbit)];
}

export function toOngoing(encounter) {
    const rollQty = (_arg1) => {
        if (_arg1[1] == null) {
            const name_1 = _arg1[0];
            let qty;
            const matchValue = tryFind(name_1, monsterKinds);
            if (matchValue == null) {
                qty = 1;
            }
            else {
                const k = matchValue;
                qty = RollSpec__roll(k.numberAppearing);
            }
            return [name_1, qty];
        }
        else {
            const roll = _arg1[1];
            const name = _arg1[0];
            return [name, RollSpec__roll(roll)];
        }
    };
    return new OngoingEncounter(map_1(rollQty, encounter.monsters), new FightResult(2), encounter.inLair);
}

export function beginEncounter(next, rest, adventureState) {
    const ribbit = StateMonad_runNoResult(adventureState.ribbit, StateMonad_StateBuilder__Delay_Z38F4EA44(StateMonad_stateChange, uncurry(2, () => StateMonad_StateBuilder__For_4BCC29DA(StateMonad_stateChange, next.monsters, uncurry(2, (_arg1) => {
        const qty = _arg1[1] | 0;
        const monsterKind = _arg1[0];
        return Universal_Detail$2__get_isADND(adventureState.mainCharacter) ? StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, createByName(monsterKind, qty), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange))) : StateMonad_StateBuilder__Bind_3179(StateMonad_stateChange, createByName_1(monsterKind, qty), uncurry(2, () => StateMonad_StateBuilder__Return_1505(StateMonad_stateChange)));
    })))));
    return new AdventureState(adventureState.mainCharacter, adventureState.allies, next, rest, ribbit);
}

export function victory(encounter, state) {
    const sheet = state.mainCharacter;
    const divisor = (1 + length(state.allies)) | 0;
    let patternInput_2;
    if (sheet.tag === 1) {
        const sheet_2 = sheet.fields[0];
        const divisor_1 = (1 + length(state.allies)) | 0;
        let xpReward_1;
        const getReward_1 = (tupledArg_2) => {
            const monsterKind_3 = tupledArg_2[0];
            const qty_2 = tupledArg_2[1] | 0;
            return (FSharpMap__get_Item(monsterKinds_1, monsterKind_3).xp * qty_2) | 0;
        };
        xpReward_1 = sum(map_1(getReward_1, encounter.monsters), {
            GetZero: () => 0,
            Add: (x_2, y_1) => (x_2 + y_1),
        });
        let patternInput_1;
        const getTreasure_1 = (tupledArg_3) => {
            const monsterKind_4 = tupledArg_3[0];
            const qty_3 = tupledArg_3[1] | 0;
            const monsterKind_5 = FSharpMap__get_Item(monsterKinds_1, monsterKind_4);
            return append(encounter.inLair ? monsterKind_5.lairTreasure : empty(), collect((x_3) => x_3, replicate(qty_3, monsterKind_5.treasureType)));
        };
        patternInput_1 = Treasure_treasureValue(collect(getTreasure_1, encounter.monsters));
        const treasureDescription_1 = patternInput_1[1];
        const gpReward_1 = patternInput_1[0] | 0;
        const reward_1 = (char_2) => Universal_Detail$2__map5e_Z1D9544EA(char_2, (char_3) => (new DND5e_CharacterSheet(char_3.id, char_3.name, char_3.origin, char_3.sex, char_3.Str, char_3.Dex, char_3.Con, char_3.Int, char_3.Wis, char_3.Cha, char_3.originalRolls, char_3.hp, char_3.ac, char_3.toHit, char_3.damage, char_3.xp + ((~(~(xpReward_1 / divisor_1))) * 1), char_3.levels, char_3.traits, char_3.wealth + (~(~(gpReward_1 / divisor_1))))));
        patternInput_2 = [xpReward_1, gpReward_1, treasureDescription_1, new AdventureState(reward_1(state.mainCharacter), map_1(reward_1, state.allies), state.currentEncounter, state.scheduledEncounters, state.ribbit)];
    }
    else {
        const sheet_1 = sheet.fields[0];
        let xpReward;
        const getReward = (tupledArg) => {
            const monsterKind = tupledArg[0];
            const qty = tupledArg[1] | 0;
            return (FSharpMap__get_Item(monsterKinds, monsterKind).xp * qty) | 0;
        };
        xpReward = sum(map_1(getReward, encounter.monsters), {
            GetZero: () => 0,
            Add: (x, y) => (x + y),
        });
        let patternInput;
        const getTreasure = (tupledArg_1) => {
            const monsterKind_1 = tupledArg_1[0];
            const qty_1 = tupledArg_1[1] | 0;
            const monsterKind_2 = FSharpMap__get_Item(monsterKinds, monsterKind_1);
            return append(encounter.inLair ? monsterKind_2.lairTreasure : empty(), collect((x_1) => x_1, replicate(qty_1, monsterKind_2.treasureType)));
        };
        patternInput = Treasure_treasureValue(collect(getTreasure, encounter.monsters));
        const treasureDescription = patternInput[1];
        const gpReward = patternInput[0] | 0;
        const reward = (char) => Universal_Detail$2__map2e_Z1FC644CA(char, (char_1) => (new ADND2nd_CharacterSheet(char_1.id, char_1.name, char_1.origin, char_1.sex, char_1.Str, char_1.Dex, char_1.Con, char_1.Int, char_1.Wis, char_1.Cha, char_1.exceptionalStrength, char_1.originalRolls, char_1.hp, char_1.ac, char_1.attacks, char_1.toHitBonus, char_1.damage, char_1.xp + ((~(~(xpReward / divisor))) * 1), char_1.levels, char_1.traits, char_1.wealth + (~(~(gpReward / divisor))))));
        patternInput_2 = [xpReward, gpReward, treasureDescription, new AdventureState(reward(state.mainCharacter), map_1(reward, state.allies), state.currentEncounter, state.scheduledEncounters, state.ribbit)];
    }
    const xp_2 = patternInput_2[0] | 0;
    const treasureDescription_2 = patternInput_2[2];
    const state$0027 = patternInput_2[3];
    const gpReward_2 = patternInput_2[1] | 0;
    if (divisor === 1) {
        return [state$0027, `You earn ${xp_2} XP! As for material rewards... you find ${treasureDescription_2}.`];
    }
    else if (gpReward_2 === 0) {
        return [state$0027, `You earn ${xp_2} XP! (${(~(~(xp_2 / divisor)))} XP each.) As for material rewards... you find ${treasureDescription_2}.`];
    }
    else {
        return [state$0027, `You earn ${xp_2} XP! (${(~(~(xp_2 / divisor)))} XP each.) As for material rewards... you find ${treasureDescription_2} and split it amongst yourselves (${(~(~(gpReward_2 / divisor)))} gp each).`];
    }
}

export function fightUntilFixedPoint(adventureState) {
    const result = Universal_Detail$2__get_isADND(adventureState.mainCharacter) ? fightOneRound(adventureState.ribbit) : fightUntilFixedPoint_1(adventureState.ribbit);
    const adv = new AdventureState(adventureState.mainCharacter, adventureState.allies, map_2((e) => (new OngoingEncounter(e.monsters, result.outcome, e.inLair)), adventureState.currentEncounter), adventureState.scheduledEncounters, result.ribbit);
    const matchValue = result.outcome;
    switch (matchValue.tag) {
        case 0: {
            const patternInput = victory(value_2(adv.currentEncounter), adv);
            const msg = patternInput[1];
            const adv_1 = patternInput[0];
            return [result.outcome, append(result.msgs, ofArray(["Victory!!!", msg])), adv_1];
        }
        case 1: {
            return [result.outcome, append(result.msgs, singleton("You have been defeated!!! The worms now feast on your flesh.")), adv];
        }
        default: {
            return [result.outcome, result.msgs, adv];
        }
    }
}

export function easy() {
    return chooseRandom([AdventureSpec_fresh("You hire on as a caravan guard.", singleton(Encounter_wandering("One night, kobolds attack! Your fellow guards cravenly flee but you fight bravely.", singleton(["Kobold", RollSpec_create_Z37302880(1, 3)])))), AdventureSpec_fresh("You go to visit your brother.", singleton(Encounter_wandering("You are attacked by wolves on the Connecticut turnpike!", singleton(["Wolf", RollSpec_create_Z37302880(1, 2)])))), AdventureSpec_fresh("You go on a safari hunting antelopes in the Pridelands.", singleton(Encounter_wandering("Vicious jackals attack you!", singleton(["Jackal", RollSpec_create_4F7761DC(1, 4, 1)])))), AdventureSpec_fresh("Weird noises are coming from a widow\u0027s back yard.", singleton(Encounter_lair("When you enter the yard, rabid porcupines attack!", singleton(["Porcupine", RollSpec_create_4F7761DC(1, 2, 1)]))))]);
}

export function hard() {
    let inputRecord;
    return chooseRandom([AdventureSpec_fresh("You hire on as a caravan guard.", singleton(Encounter_wandering("One night, kobolds attack! Your fellow guards betray you and fight with the kobolds!", ofArray([["Kobold", RollSpec_create_Z37302880(2, 6)], ["Guard", RollSpec_create_Z37302880(1, 4)]])))), AdventureSpec_fresh("You hire on as a caravan guard.", singleton(Encounter_wandering("One night, kobolds attack! Your fellow guards betray you and fight with the kobolds!", ofArray([["Kobold", RollSpec_create_Z37302880(2, 6)], ["Guard", RollSpec_create_Z37302880(1, 4)]])))), AdventureSpec_fresh("You hire on as a caravan guard.", singleton(Encounter_wandering("One night, hobgoblins attack! Your fellow guards cravenly flee but you fight bravely.", singleton(["Hobgoblin", RollSpec_create_Z37302880(2, 6)])))), AdventureSpec_fresh("You go to visit your brother.", singleton(Encounter_wandering("You are attacked by many wolves on the Connecticut turnpike!", singleton(["Wolf", RollSpec_create_Z37302880(2, 4)])))), AdventureSpec_fresh("You are hungry for honey. You decide to go get some.", singleton(Encounter_wandering("Bears don\u0027t like it when people steal honey from their trees!", singleton(["Black Bear", RollSpec_create_Z37302880(1, 3)])))), AdventureSpec_fresh("You are hungry for honey. You decide to go get some.", singleton(Encounter_wandering("Owlbears don\u0027t like it when people steal honey from their trees!", singleton(["Owlbear", void 0])))), (inputRecord = AdventureSpec_fresh("An animal trainer is offering a 1000 gp reward for owlbear eggs.", singleton(Encounter_lair("You find owlbear eggs. Unfortunately the eggs are guarded!", singleton(["Owlbear", RollSpec_create_Z37302880(1, 2)])))), new AdventureSpec(inputRecord.description, inputRecord.encounters, inputRecord.allies, inputRecord.bonusXP, 1000))]);
}

export function deadly() {
    return chooseRandomExponentialDecay(0.5, ofArray([AdventureSpec_fresh("Rumors say the kobolds are growing restless.", ofArray([Encounter_wandering("Kobolds attack you in your home!", singleton(["Kobold", RollSpec_create_Z37302880(2, 4)])), Encounter_wandering("Kobolds attack the town!", singleton(["Kobold", void 0])), Encounter_lair("You counterattack the kobold lair! There are many kobolds here.", singleton(["Kobold", RollSpec_create_Z37302880(8, 10)]))])), AdventureSpec_fresh("You climb a giant beanstalk looking for trouble.", singleton(Encounter_lair("The hill giants are not pleased to see you!", singleton(["Hill Giant", void 0])))), AdventureSpec_fresh("You climb a giant beanstalk looking for trouble.", singleton(Encounter_lair("The frost giants are not pleased to see you!", singleton(["Frost Giant", void 0]))))]));
}

//# sourceMappingURL=Adventure.fs.js.map
