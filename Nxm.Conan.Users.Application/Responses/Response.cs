﻿namespace Nxm.Conan.Users.Application.Responses
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}