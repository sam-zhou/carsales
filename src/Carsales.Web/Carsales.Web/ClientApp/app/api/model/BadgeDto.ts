/**
 * Carsales.Api
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

import * as models from './models';

export interface BadgeDto {
    name?: string;

    modelId?: number;

    model?: models.ModelDto;

    engine?: BadgeDto.EngineEnum;

    doors?: number;

    wheels?: number;

    badgeType?: BadgeDto.BadgeTypeEnum;

    year?: number;

    id?: number;

}
export namespace BadgeDto {
    export enum EngineEnum {
        NUMBER_0 = <any> 0,
        NUMBER_1200 = <any> 1200,
        NUMBER_1500 = <any> 1500,
        NUMBER_1600 = <any> 1600,
        NUMBER_1800 = <any> 1800,
        NUMBER_2000 = <any> 2000,
        NUMBER_2400 = <any> 2400,
        NUMBER_3000 = <any> 3000,
        NUMBER_3500 = <any> 3500,
        NUMBER_4000 = <any> 4000
    }
    export enum BadgeTypeEnum {
        NUMBER_101 = <any> 101,
        NUMBER_102 = <any> 102,
        NUMBER_103 = <any> 103,
        NUMBER_201 = <any> 201,
        NUMBER_202 = <any> 202
    }
}
