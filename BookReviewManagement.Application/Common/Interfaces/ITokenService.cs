﻿namespace BookReviewManagement.Application.Common.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}