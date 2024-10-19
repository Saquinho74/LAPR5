namespace DDDNetCore.Mappers
{
    public interface IMapper<E,D,C>
    {
        E toDomain(D dto);
        D toDto(E entity);
        E toDomain(C createDto);

    }
}