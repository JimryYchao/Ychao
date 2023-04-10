namespace Ychao.Diagnostics
{
    public enum ExceptionResource
    {
        Arg_ArrayPlusOffTooSmall,
        Arg_NonZeroLowerBound,
        Arg_RankMultiDimNotSupported,
        Arg_RegKeyDelHive,
        Arg_RegKeyStrLenBug,
        Arg_RegSetStrArrNull,
        Arg_RegSetMismatchedKind,
        Arg_RegSubKeyAbsent,
        Arg_RegSubKeyValueAbsent,

        Serialization_InvalidOnDeser,
        Serialization_MissingKeys,
        Serialization_NullKey,

        NotSupported_KeyCollectionSet,
        NotSupported_ValueCollectionSet,
        NotSupported_ReadOnlyCollection,



        NotSupported_SortedListNestedWrite,
        NotSupported_InComparableType,

        Security_RegistryPermission,

        UnauthorizedAccess_RegistryNoWrite,

        ObjectDisposed_RegKeyClosed,
    }
}
