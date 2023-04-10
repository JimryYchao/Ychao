namespace Ychao.Diagnostics.Exceptions
{
    internal class ExceptionHelper
    {
        internal static string GetArgumentName(ExceptionArgument argument)
        {
            return argument switch
            {
                ExceptionArgument.array => "array",
                ExceptionArgument.arrayIndex => "arrayIndex",
                ExceptionArgument.capacity => "capacity",
                ExceptionArgument.collection => "collection",
                ExceptionArgument.list => "list",
                ExceptionArgument.converter => "converter",
                ExceptionArgument.count => "count",
                ExceptionArgument.dictionary => "dictionary",
                ExceptionArgument.dictionaryCreationThreshold => "dictionaryCreationThreshold",
                ExceptionArgument.index => "index",
                ExceptionArgument.info => "info",
                ExceptionArgument.key => "key",
                ExceptionArgument.match => "match",
                ExceptionArgument.obj => "obj",
                ExceptionArgument.queue => "queue",
                ExceptionArgument.stack => "stack",
                ExceptionArgument.startIndex => "startIndex",
                ExceptionArgument.value => "value",
                ExceptionArgument.name => "name",
                ExceptionArgument.mode => "mode",
                ExceptionArgument.item => "item",
                ExceptionArgument.options => "options",
                ExceptionArgument.view => "view",
                ExceptionArgument.sourceBytesToCopy => "sourceBytesToCopy",
                _ => string.Empty,
            };
        }

        internal static string GetResourceName(ExceptionResource resource)
        {
            return resource switch
            {

                ExceptionResource.Arg_ArrayPlusOffTooSmall => "Arg_ArrayPlusOffTooSmall",
                ExceptionResource.Arg_RankMultiDimNotSupported => "Arg_RankMultiDimNotSupported",
                ExceptionResource.Arg_NonZeroLowerBound => "Arg_NonZeroLowerBound",
                ExceptionResource.Arg_RegSetStrArrNull => "Arg_RegSetStrArrNull",
                ExceptionResource.Arg_RegSubKeyAbsent => "Arg_RegSubKeyAbsent",
                ExceptionResource.Arg_RegSubKeyValueAbsent => "Arg_RegSubKeyValueAbsent",
                ExceptionResource.Arg_RegKeyDelHive => "Arg_RegKeyDelHive",
                ExceptionResource.Arg_RegSetMismatchedKind => "Arg_RegSetMismatchedKind",
                ExceptionResource.Arg_RegKeyStrLenBug => "Arg_RegKeyStrLenBug",


                ExceptionResource.NotSupported_KeyCollectionSet => "NotSupported_KeyCollectionSet",
                ExceptionResource.NotSupported_ReadOnlyCollection => "NotSupported_ReadOnlyCollection",
                ExceptionResource.NotSupported_ValueCollectionSet => "NotSupported_ValueCollectionSet",
                ExceptionResource.NotSupported_SortedListNestedWrite => "NotSupported_SortedListNestedWrite",
                ExceptionResource.NotSupported_InComparableType => "NotSupported_InComparableType",

                ExceptionResource.Serialization_InvalidOnDeser => "Serialization_InvalidOnDeser",
                ExceptionResource.Serialization_MissingKeys => "Serialization_MissingKeys",
                ExceptionResource.Serialization_NullKey => "Serialization_NullKey",

                ExceptionResource.Security_RegistryPermission => "Security_RegistryPermission",

                ExceptionResource.UnauthorizedAccess_RegistryNoWrite => "UnauthorizedAccess_RegistryNoWrite",

                ExceptionResource.ObjectDisposed_RegKeyClosed => "ObjectDisposed_RegKeyClosed",

                _ => string.Empty,
            };

        }

        internal static string GetInvalidOperationResource(ExceptionInvalidOperationResource resource)
        {
            return resource switch
            {
                ExceptionInvalidOperationResource.Cannot_Remove_From_Stack_Or_Queue => "InvalidOperation_CannotRemoveFromStackOrQueue",
                ExceptionInvalidOperationResource.Empty_Queue => "InvalidOperation_EmptyQueue",
                ExceptionInvalidOperationResource.Enum_Op_CantHappen => "InvalidOperation_EnumOpCantHappen",
                ExceptionInvalidOperationResource.Enum_Failed_Version => "InvalidOperation_EnumFailedVersion",
                ExceptionInvalidOperationResource.Empty_Stack => "InvalidOperation_EmptyStack",
                ExceptionInvalidOperationResource.Enum_Not_Started => "InvalidOperation_EnumNotStarted",
                ExceptionInvalidOperationResource.Enum_Ended => "InvalidOperation_EnumEnded",
                ExceptionInvalidOperationResource.No_Value => "InvalidOperation_NoValue",
                ExceptionInvalidOperationResource.Reg_Remove_Sub_Key => "InvalidOperation_RegRemoveSubKey",
                _ => default!
            };
        }

        internal static string GetArgumentResourceName(ExceptionArgumentResource resource)
        {
            return resource switch
            {
                ExceptionArgumentResource.Invalid_Of_Length => "Invalid Of Length",
                ExceptionArgumentResource.Implement_IComparable => "Argument_ImplementIComparable",
                ExceptionArgumentResource.Adding_Duplicate => "Argument_AddingDuplicate",
                ExceptionArgumentResource.Out_Of_Range__Bigger_Than_Collection => "ArgumentOutOfRange_BiggerThanCollection",
                ExceptionArgumentResource.Invalid_Array_Type => "Argument_InvalidArrayType",
                ExceptionArgumentResource.Item_Not_Exist => "Argument_ItemNotExist",
                ExceptionArgumentResource.Invalid_Type => "Argument_InvalidType",
                ExceptionArgumentResource.Invalid_Argument_For_Comparison => "Argument_InvalidArgumentForComparison",
                ExceptionArgumentResource.Invalid_Registry_Key_PermissionCheck => "Argument_InvalidRegistryKeyPermissionCheck",
                ExceptionArgumentResource.Invalid_Registry_View_Check => "Argument_InvalidRegistryViewCheck",
                ExceptionArgumentResource.Invalid_Registry_Options_Check => "Argument_InvalidRegistryOptionsCheck",

                _ => string.Empty
            };
        }

    }
}
