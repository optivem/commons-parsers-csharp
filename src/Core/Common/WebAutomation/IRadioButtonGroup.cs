﻿namespace Optivem.Core.Common.WebAutomation
{
    public interface IRadioButtonGroup
    {
        void SelectValue(string key);

        string ReadSelectedValue();

        bool HasSelected();

        int Count { get; }

        string ReadValue(int index);
    }

    // TODO: VC: DELETE


    /*
    public interface IRadioGroup<T> : IRadioButtonGroup
    {
        void Select(T key);

        T ReadSelected();

        T Read(int index);
    }
    */

}