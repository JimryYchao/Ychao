namespace Ychao.Diagnostics
{
    public enum ExceptionArgument
    {
        item,
        capacity,
        index,
        count,
        key,
        value,
        info,
        name,
        obj,
        array,
        dictionary,
        dictionaryCreationThreshold,
        queue,
        collection,
        list,
        match,
        converter,
        stack,
        startIndex,
        arrayIndex,
        mode,
        options,
        view,
        sourceBytesToCopy
    }

    public enum ExceptionArgumentResource
    {
        Implement_IComparable,
        Invalid_Type,
        Invalid_Argument_For_Comparison,
        Invalid_Registry_Key_PermissionCheck,
        Invalid_Of_Length,
        Item_Not_Exist,
        Invalid_Registry_Options_Check,
        Adding_Duplicate,
        Invalid_Registry_View_Check,
        Invalid_Array_Type,

        ArgumentOutOfRange_Count,
        ArgumentOutOfRange_Index,
        ArgumentOutOfRange_NeedNonNegNum,
        ArgumentOutOfRange_InvalidThreshold,
        ArgumentOutOfRange_ListInsert,
        Out_Of_Range__Bigger_Than_Collection,
        ArgumentOutOfRange_SmallCapacity,
    }
}
