import { IActor } from './actor';
import { ITrailer } from './trailer';
export interface ITraillerActor {
    id: number,
    idTrailler: number,
    idActor: number,
    actor: IActor[],
    trailler: ITrailer
}
