using UnityEngine;
using System.Collections;

public interface IController {

    CharacterBaseModel Character { get; }
    void Move(float movement);
    void Action();
}
