// Global using directives

global using System.IdentityModel.Tokens.Jwt;
global using System.Reflection;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
global using BookReviewManagement.Application.Common.Interfaces;
global using BookReviewManagement.Domain.Entities;
global using BookReviewManagement.Domain.Extensions;
global using BookReviewManagement.Domain.Interfaces;
global using BookReviewManagement.Infrastructure.Auth.Services;
global using BookReviewManagement.Infrastructure.Data;
global using BookReviewManagement.Infrastructure.Interceptors;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;